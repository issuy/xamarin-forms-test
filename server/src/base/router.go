package base

import (
	"log"
	"net/http"

	"github.com/gorilla/mux"
	"time"

	"golang.org/x/net/context"
	"google.golang.org/appengine"
	"google.golang.org/appengine/datastore"
)

type Route struct {
	Name              string
	Method            string
	Pattern           string
	Updated           bool
	Authenticated     bool
	RouterHandlerFunc RouterHandlerFunc
}
type Routes []Route
type RouterHandlerFunc func(context.Context, http.ResponseWriter, *http.Request) error

func NewRouter(
	routes Routes,
	mainRouteFunc func(route Route, ctx context.Context, w http.ResponseWriter, r *http.Request) error,
	errorRouteFunc func(ctx context.Context, w http.ResponseWriter, err error),
) *mux.Router {
	router := mux.NewRouter().StrictSlash(true)
	for _, route := range routes {
		var handler http.Handler
		handler = RouteHandler(route, mainRouteFunc, errorRouteFunc)

		router.
			Methods(route.Method).
			Path(route.Pattern).
			Name(route.Name).
			Handler(handler)
	}
	return router
}

func RouteHandler(
	route Route,
	mainRouteFunc func(route Route, ctx context.Context, w http.ResponseWriter, r *http.Request) error,
	errorRouteFunc func(ctx context.Context, w http.ResponseWriter, err error),
) http.Handler {
	return http.HandlerFunc(func(w http.ResponseWriter, r *http.Request) {
		start := time.Now()

		ctx := appengine.NewContext(r)

		if route.Updated {
			err := datastore.RunInTransaction(ctx, func(ctx context.Context) error {
				return mainRouteFunc(route, ctx, w, r)
			}, nil)
			if err != nil {
				errorRouteFunc(ctx, w, err)
			}
		} else {
			err := mainRouteFunc(route, ctx, w, r)
			if err != nil {
				errorRouteFunc(ctx, w, err)
			}
		}

		log.Printf(
			"%s\t%s\t%s\t%s",
			r.Method,
			r.RequestURI,
			route.Name,
			time.Since(start),
		)
	})
}

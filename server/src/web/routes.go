package web

import (
	"base"
	"log"
	"net/http"
	"web/views"

	"golang.org/x/net/context"
)

var Routes = base.Routes{
	base.Route{
		"Index",
		"GET",
		"/",
		false,
		false,
		views.Index,
	},
}

func MainRoute(route base.Route, ctx context.Context, w http.ResponseWriter, r *http.Request) error {
	w.Header().Set("Content-Type", "text/html; charset=UTF-8")
	if route.Authenticated {
		if err := AuthenticatedRoute(ctx, w, r); err != nil {
			return err
		}
	}
	if err := route.RouterHandlerFunc(ctx, w, r); err != nil {
		return err
	}
	return nil
}

func AuthenticatedRoute(ctx context.Context, w http.ResponseWriter, r *http.Request) error {
	log.Printf("%s", "[web]skip auth.")
	return nil
}

func ErrorRoute(ctx context.Context, w http.ResponseWriter, err error) {
	var message = ""
	if base.IsEnv(ctx, base.Test) {
		message = err.Error()
	}
	http.Error(w, message, 500)
}

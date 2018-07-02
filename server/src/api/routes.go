package api

import (
	"api/views"
	"base"
	"log"
	"net/http"

	"golang.org/x/net/context"
)

var Routes = base.Routes{
	base.Route{
		"Login",
		"POST",
		"/login",
		true,
		true,
		views.Login,
	},
	base.Route{
		"TodoIndex",
		"GET",
		"/todos",
		false,
		true,
		views.TodoIndex,
	},
	base.Route{
		"TodoShow",
		"GET",
		"/todos/{todoId}",
		false,
		true,
		views.TodoShow,
	},
	base.Route{
		"TodoCreate",
		"POST",
		"/todos",
		true,
		true,
		views.TodoCreate,
	},
}

func MainRoute(route base.Route, ctx context.Context, w http.ResponseWriter, r *http.Request) error {
	w.Header().Set("Content-Type", "application/json; charset=UTF-8")
	if route.Authenticated {
		if err := AuthenticatedRoute(ctx, w, r); err != nil {
			return err
		}
	}
	if err := route.RouterHandlerFunc(ctx, w, r); err != nil {
		return err
	}

	w.Header().Set("App-Status", "1")
	return nil
}

func AuthenticatedRoute(ctx context.Context, w http.ResponseWriter, r *http.Request) error {
	log.Printf("%s", "[api]skip auth.")
	return nil
}

func ErrorRoute(ctx context.Context, w http.ResponseWriter, err error) {
	var message = ""
	if base.IsEnv(ctx, base.Test) {
		message = err.Error()
	}
	http.Error(w, message, 500)
}

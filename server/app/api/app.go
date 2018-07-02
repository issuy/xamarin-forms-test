package main

import (
	"api"
	"base"
	"net/http"
)

func init() {
	router := base.NewRouter(api.Routes, api.MainRoute, api.ErrorRoute)
	http.Handle("/", router)
}

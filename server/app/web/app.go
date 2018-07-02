package main

import (
	"base"
	"net/http"
	"web"
)

func init() {
	router := base.NewRouter(web.Routes, web.MainRoute, web.ErrorRoute)
	http.Handle("/", router)
}

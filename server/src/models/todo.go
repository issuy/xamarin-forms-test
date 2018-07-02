package models

import "time"

type Todo struct {
	Id        int64     `json:"id" datastore:"-"`
	Name      string    `json:"name"`
	Completed bool      `json:"completed" datastore:"completed"`
	Due       time.Time `json:"due" datastore:"due"`
}

type Todos []Todo

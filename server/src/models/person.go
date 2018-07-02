package models

type Person struct {
	Id        int64     `json:"id" datastore:"-"`
	Name      string `json:"name" datastore:"name"`
	CreatedAt int64 `json:"created_at" datastore:"created_at"`
}

package models

import (
	"golang.org/x/net/context"
	"google.golang.org/appengine/datastore"
)

/// Person ///

var kindperson = "Person"

func RepoFindPerson(ctx context.Context, id int64, obj *Person) error {
	key := datastore.NewKey(ctx, kindperson, "", id, nil)
	err := datastore.Get(ctx, key, obj)
	if err != nil {
		return err
	}
	obj.Id = key.IntID()
	return nil
}

func RepoCreatePerson(ctx context.Context, obj *Person) error {
	key := datastore.NewIncompleteKey(ctx, kindperson, nil)
	newkey, err := datastore.Put(ctx, key, obj)
	if err != nil {
		return err
	}
	obj.Id = newkey.IntID()
	return nil
}

/// Todo ///

var kindtodo = "Todo"

func RepoGetAllTodos(ctx context.Context, todos *[]Todo) error {
	q := datastore.NewQuery(kindtodo)
	_, err := q.GetAll(ctx, todos)
	if err != nil {
		return err
	}
	return nil
}

func RepoFindTodo(ctx context.Context, id int64, todo *Todo) error {
	key := datastore.NewKey(ctx, kindtodo, "", id, nil)
	err := datastore.Get(ctx, key, todo)
	if err != nil {
		return err
	}
	todo.Id = key.IntID()
	return nil
}

func RepoCreateTodo(ctx context.Context, todo *Todo) error {
	key := datastore.NewIncompleteKey(ctx, kindtodo, nil)
	newkey, err := datastore.Put(ctx, key, todo)
	if err != nil {
		return err
	}
	todo.Id = newkey.IntID()
	return nil
}

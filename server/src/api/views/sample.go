package views

import (
	"encoding/json"
	"net/http"

	"api/views/structs"
	"github.com/gorilla/mux"
	"io"
	"io/ioutil"
	"models"
	"strconv"

	"golang.org/x/net/context"
)

func TodoIndex(ctx context.Context, w http.ResponseWriter, r *http.Request) error {
	w.WriteHeader(http.StatusOK)
	var todos []models.Todo
	if err := models.RepoGetAllTodos(ctx, &todos); err != nil {
		return err
	}

	var res = structs.TodoIndexResponse{
		todos,
	}

	if err := json.NewEncoder(w).Encode(res); err != nil {
		return err
	}
	return nil
}

func TodoShow(ctx context.Context, w http.ResponseWriter, r *http.Request) error {
	vars := mux.Vars(r)
	todoId, err := strconv.Atoi(vars["todoId"])
	if err != nil {
		return err
	}

	var todo models.Todo
	if err := models.RepoFindTodo(ctx, int64(todoId), &todo); err != nil {
		return err
	}

	var res = structs.TodoShowResponse{
		&todo,
	}

	if err := json.NewEncoder(w).Encode(res); err != nil {
		return err
	}
	return nil
}

func TodoCreate(ctx context.Context, w http.ResponseWriter, r *http.Request) error {
	var todo models.Todo
	body, err := ioutil.ReadAll(io.LimitReader(r.Body, 1048576))
	if err != nil {
		return err
	}
	if err := r.Body.Close(); err != nil {
		return err
	}
	if err := json.Unmarshal(body, &todo); err != nil {
		return err
	}

	if err := models.RepoCreateTodo(ctx, &todo); err != nil {
		return err
	}
	var res = structs.TodoCreateResponse{
		&todo,
	}
	if err := json.NewEncoder(w).Encode(res); err != nil {
		return err
	}
	return nil
}

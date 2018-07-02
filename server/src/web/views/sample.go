package views

import (
	"fmt"
	"net/http"

	"golang.org/x/net/context"
	"models"
)

func Index(ctx context.Context, w http.ResponseWriter, r *http.Request) error {
	var todos []models.Todo
	if err := models.RepoGetAllTodos(ctx, &todos); err != nil {
		return err
	}
	num := len(todos)
	fmt.Fprintln(w, num)
	return nil
}

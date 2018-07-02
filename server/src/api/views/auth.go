package views

import (
	"net/http"
	"models"
	"encoding/json"
	"api/views/structs"

	"golang.org/x/net/context"
	"time"
)

func Login(ctx context.Context, w http.ResponseWriter, r *http.Request) error {
	// FIXME - 認証系をFacebookで
	var person models.Person

	// FIXME - お試し
	//if err := models.RepoCreatePerson(ctx, &person); err != nil{
	if err := models.RepoFindPerson(ctx, 5629499534213120, &person); err != nil {
		return err
	}
	time.Sleep(1 * time.Second) // 3秒休む

	var res = structs.LoginResponse{
		&person,
	}
	if err := json.NewEncoder(w).Encode(res); err != nil {
		return err
	}
	return nil
}

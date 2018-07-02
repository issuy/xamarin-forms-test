package structs

import "models"

const ApiErrorNone = 1

type LoginResponse struct {
	Person *models.Person `json:"person"`
}

type TodoIndexResponse struct {
	Todos models.Todos `json:"todos"`
}

type TodoShowResponse struct {
	Todo *models.Todo `json:"todo"`
}

type TodoCreateResponse struct {
	Todo *models.Todo `json:"todo"`
}

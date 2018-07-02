package base

import (
	"golang.org/x/net/context"
	"google.golang.org/appengine"
)

type Env int

const (
	Test Env = iota
	Prod
)

func IsEnv(ctx context.Context, env Env) bool {
	return env == getEnv(ctx)
}

func getEnv(ctx context.Context) Env {
	switch appengine.AppID(ctx) {
	case "test":
		return Test
	case "prod":
		return Prod
	default:
		return Test
	}
}

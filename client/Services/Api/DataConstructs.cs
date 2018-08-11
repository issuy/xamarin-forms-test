using System.Collections.Generic;

namespace client.Services.Api
{
    public class LoginRequest : IRequest
    {
    }

    public class LoginResponse : IResponse
    {
        public Models.Person Person { get; set; }
    }

    public class TodoIndexRequest : IRequest
    {
    }

    public class TodoIndexResponse : IResponse
    {
        public List<Models.Todo> Todos { get; set; }
    }

    public class TodoShowRequest : IRequest
    {
        public long Id { get; set; }
    }

    public class TodoShowResponse : IResponse
    {
        public Models.Todo Todo { get; set; }
    }

    public class TodoCreateRequest : IRequest
    {
        public string Name { get; set; }
    }

    public class TodoCreateResponse : IResponse
    {
        public Models.Todo Todo { get; set; }
    }
}

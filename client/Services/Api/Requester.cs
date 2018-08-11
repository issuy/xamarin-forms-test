namespace client.Services.Api
{
    public class LoginRequester : BasePostRequester<LoginRequest, LoginResponse>
    {
        public override string Path { get { return $"login"; } }
    }

    public class TodoIndexRequester : BaseGetRequester<TodoIndexRequest, TodoIndexResponse>
    {
        public override string Path { get { return $"todos"; } }
    }

    public class TodoShowRequester : BaseGetRequester<TodoShowRequest, TodoShowResponse>
    {
        public override string Path { get { return $"todos/{Request.Id}"; } }
    }

    public class TodoCreateRequester : BasePostRequester<TodoCreateRequest, TodoCreateResponse>
    {
        public override string Path { get { return $"todos"; } }
    }
}

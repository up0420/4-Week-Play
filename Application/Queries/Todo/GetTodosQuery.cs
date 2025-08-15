// Application/Queries/Todo/GetTodosQuery.cs
namespace Application.Queries.Todo
{
    public class GetTodosQuery
    {
        public Guid UserId { get; set; }

        public GetTodosQuery(Guid userId)
        {
            UserId = userId;
        }
    }
}

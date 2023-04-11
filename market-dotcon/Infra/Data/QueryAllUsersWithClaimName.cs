using Dapper;
using market_dotcon.Endpoints.Employees;
using Microsoft.Data.SqlClient;

namespace market_dotcon.Infra.Data;

public class QueryAllUsersWithClaimName
{
    private readonly IConfiguration cfg;

    public QueryAllUsersWithClaimName(IConfiguration cfg)
    {
        this.cfg = cfg;
    }

    public IEnumerable<EmployeeResponse> Execute(int page, int rows)
    {
        var db = new SqlConnection(cfg["ConnectionString:DotConDb"]);
        return db.Query<EmployeeResponse>(
            @"SELECT Email, ClaimValue AS Name
              FROM AspNetUsers u INNER JOIN AspNetUserClaims c
              ON u.Id = c.UserId AND c.ClaimType = 'Name'
              ORDER BY name
              OFFSET (@page - 1) * @rows ROWS FETCH NEXT @rows ROWS ONLY;",
            new { page, rows }
            );
    }
}

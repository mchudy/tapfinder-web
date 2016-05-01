using GenericLibsBase;

namespace PubApp.Tests
{
    public class DbModelTests
    {

        // not working as expected

        //[Fact]
        //public void DbContext_model_should_match_actual_database_simple_check()
        //{
        //    using (var ctx = new ApplicationContext())
        //    {
        //        var comparer = new CompareEfSql();
        //        var status = comparer.CompareEfWithDb(ctx);

        //        status.IsValid.Should().BeTrue(GetErrorMessage(status));
        //    }
        //}

        //[Fact]
        //public void DbContext_model_should_match_actual_database_detailed_check()
        //{
        //    using (var ctx = new ApplicationContext())
        //    {
        //        var comparer = new CompareSqlSql();
        //        var status = comparer.CompareEfGeneratedSqlToSql(ctx, "DbConnection");

        //        status.IsValid.Should().BeTrue(GetErrorMessage(status));
        //    }
        //}

        private static string GetErrorMessage(ISuccessOrErrors status)
        {
            string message = status.GetAllErrors() + string.Join("\n", status.Warnings);
            return message;
        }
    }
}

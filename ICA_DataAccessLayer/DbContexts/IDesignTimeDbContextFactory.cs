namespace ICA_DataAccessLayer.DbContexts
{
    public interface IDesignTimeDbContextFactory<T>
    {
        public InfusionPlanDbContext CreateDbContext(string[] args);
    }
}
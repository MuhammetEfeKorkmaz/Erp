namespace _IdentityServer.Entities.DbModels
{
    public class UserOperationClaims : BaseModel
    {
        public int UserFID { get; set; }
        public int OperationClaimsFID { get; set; }
    }
}

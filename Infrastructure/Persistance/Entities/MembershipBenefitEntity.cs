
namespace Infrastructure.Persistance.Entities;

public sealed class MembershipBenefitEntity
{
    public string Id { get; set; } = null!;
    public string MembershipId { get; set; } = null!;
    public string BenefitId { get; set; } = null!;
    public string Benefits { get; set; } = null!;
    public MembershipEntity Membership { get; set; } = null!;

}

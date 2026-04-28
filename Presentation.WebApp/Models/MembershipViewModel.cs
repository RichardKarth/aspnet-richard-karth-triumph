using Domain.Aggregates.Memberships;

namespace Presentation.WebApp.Models;

public class MembershipViewModel
{
    public IEnumerable<Membership> Memberships { get; set; } = [];

}

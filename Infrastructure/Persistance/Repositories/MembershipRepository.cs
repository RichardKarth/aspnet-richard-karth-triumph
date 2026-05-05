using Domain.Abstractions.Repositories;
using Domain.Aggregates.Memberships;
using Infrastructure.Persistance.Contexts;
using Infrastructure.Persistance.Entities.Memberships;

namespace Infrastructure.Persistance.Repositories;

public sealed class MembershipRepository(DataContext context) : RepositoryBase<Membership, string, MembershipEntity, DataContext>(context), IMembershipRepository
{
    protected override void ApplyPropertyUpdates(Membership model, MembershipEntity entity)
    {
        throw new NotImplementedException();
    }

    protected override string GetId(Membership model)
    {
        return model.Id;
    }

    protected override Membership ToDomainModel(MembershipEntity entity)
    {

        var benefits = new List<string>();
        foreach(var benefit in entity.Benefits)
        {
            benefits.Add(benefit.Benefits);
        }


        var model = Membership.Rehydrate(entity.Id, 
            entity.Title,
            entity.Description, 
            benefits, 
            entity.Price, 
            entity.MonthlyClasses);
        return model;
    }

    protected override MembershipEntity ToEntity(Membership model)
    {
        var entity = new MembershipEntity
        {
            Id = model.Id,
            Title = model.Title,
            Description = model.Description,
           
            Price = model.Price,
            MonthlyClasses = model.MonthlyClasses

        };
        foreach(var benefit in model.Benefits)
        entity.Benefits.Add(new MembershipBenefitEntity
        {
            Id = Guid.NewGuid().ToString(),
            Benefits = benefit,
            MembershipId = model.Id
        });


        return entity;
    }
}

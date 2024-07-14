using Domain.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Data.Repositories;

namespace Data.Repositories
{
    public class ItemRepository(RutinaContext context) : Repository<Item>(context), IItemRepository
    {
    }
}

using Pedfast.Entities;
using Pedfast.Models;
using Microsoft.EntityFrameworkCore;

namespace Pedfast.Features.Status;

public class StatusService(PedfastDbContext db)
{
    private readonly PedfastDbContext _db = db;


    public async Task<List<StatusModel>> GetStatus()
    {
         var response = await _db.PagamentoStatuses
            .Select(x => new StatusModel
            {
                Id = x.IdS,
                Stutus = x.StatuComp
            })
            .ToListAsync();



        return response;
    }
}   
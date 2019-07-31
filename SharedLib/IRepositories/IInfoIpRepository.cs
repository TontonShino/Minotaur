using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SharedLib.IRepositories
{
    public interface IInfoIpRepository
    {
        InfoIP Get(int id);
        Task<InfoIP> GetAsync(int id);
        InfoIP Create(InfoIP infoIP);
        Task<InfoIP> CreateAsync(InfoIP infoIP);


    }
}

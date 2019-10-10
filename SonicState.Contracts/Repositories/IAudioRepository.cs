using SonicState.Entities;
using SonicState.Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SonicState.Contracts.Repositories
{
    public interface IAudioRepository : IRepository<Audio>
    {
        IEnumerable<AudioDetails> GetAll();

        Audio Find(string audioId);

        void Update(Audio audio);
       
    }
}

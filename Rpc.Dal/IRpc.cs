using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rpc.Dal
{
    public interface IRpc
    {
        bool IsRecordExists(string username);

        bool SaveRecord(string username, string password);

        int GetUsersCount();
    }
}

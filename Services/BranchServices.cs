using post_office.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace post_office.Services
{
    public interface IBranchService
    {
        BranchModel SaveBranch(BranchModel mdl);
    }
    public class BranchService : IBranchService
    {
        public BranchModel SaveBranch(BranchModel mdl)
        {
            return null;
        }
    }
}

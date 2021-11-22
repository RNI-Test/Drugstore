﻿using backend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Repositories.Interfaces
{
    public interface IMedicineCombinationRepository : IGenericRepository<MedicineCombination>
    {
        List<MedicineCombination> GetByFirstMedicineId(int firstMedicineId);
    }
}

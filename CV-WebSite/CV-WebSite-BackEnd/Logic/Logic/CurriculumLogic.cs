using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Entities.Entities;

namespace Logic.Logic
{
    public class CurriculumLogic
    {
        private CVContext _CVContext;
        public CurriculumLogic()
        {
            this._CVContext = new CVContext();
        }
        public void InsertCurriculumItem(CurriculumItem curriculumItem)
        {
            _CVContext.Curriculums.Add(curriculumItem);
        }
    }
}

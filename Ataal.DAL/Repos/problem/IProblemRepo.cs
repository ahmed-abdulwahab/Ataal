﻿using Ataal.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataal.DAL.Repos.problem
{
    public interface IProblemRepo
    {
        public Problem? GetProblemById(int ProblemId);
        public KeyWords? GetKeywordByProblemId(int ProblemId);
        public List<Problem>? GetAllProblems();
        public List<Problem>? GetAllProblems(int TechnicalID, int SectionId, int pageNumber);
        public List<Problem>? GetAllProblemsForCustomersSection(int SectionId, int pageNumber);
        public int ProblemIsSolved(int ProblemId);
        public int? CustomerAcceptedProblem_Offer(int TechnicalId,int ProblemId, int offerId);
        public int ProblemisVIP(int ProblemId);

        public List<Problem> get_All_Problems_for_Search(string query, int TechnicalId);
        public List<Problem> get_All_Problems_forTechincal(int TechnicalId);


        public List<Problem> GetAllSolvedProblems(int TechnicalId);
        public List<Offer> GetAllofferdProblems(int TechnicalId);

        

        //get all problems that in the same sections of tecknical and not in blocked customers
        public List<Problem> get_All_Problems_forTechincal(int technicalID, int TechnicalId);



        public int SaveChanges();

    }
}

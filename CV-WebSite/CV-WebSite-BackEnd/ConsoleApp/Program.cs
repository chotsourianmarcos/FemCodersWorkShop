// See https://aka.ms/new-console-template for more information
using Entities.Entities;
using Logic.Logic;


try
{
    Console.WriteLine("Insertando Curriculum...");
    var newCurriculum = new CurriculumItem();
    var curriculumLogic = new CurriculumLogic();
    newCurriculum.Id = 0;
    newCurriculum.IdWeb = Guid.NewGuid();
    newCurriculum.OwnerId = 0;
    newCurriculum.InsertDate = DateTime.Now;
    newCurriculum.UpdateDate = null;
    newCurriculum.IsActive = true;
    newCurriculum.IsPublic = true;
    newCurriculum.Content = "Not Implemented Yet.";
    curriculumLogic.InsertCurriculumItem(newCurriculum);
    Console.WriteLine("Curriculum insertado...");
}catch(Exception e)
{
    Console.WriteLine("Ups...");
}


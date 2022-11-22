// See https://aka.ms/new-console-template for more information
using Entities.Entities;
using Logic.Logic;


try
{
    Console.WriteLine("Insertando Curriculum...");
    var newCurriculum = new CurriculumItem();
    var curriculumLogic = new CurriculumLogic();
    curriculumLogic.InsertCurriculumItem(newCurriculum);
    Console.WriteLine("Curriculum insertado...");
}catch(Exception e)
{
    Console.WriteLine("Ups...");
}


using System;


namespace DiaryMVC.Domain.Model
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TaskTypeId { get; set; }
        public virtual TaskType TaskType { get; set; }
        public int UniversitySubjectId { get; set; }
        public virtual UniversitySubject UniversitySubject { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime? UserDeadline { get; set; }
        public DateTime? TaskEndDate { get; set; }
        public bool IsDone { get; set; }
        public bool InProgres { get; set; }
    }
}
/*
 * GŁÓWNA FUNKCJA = Dzielenie przedmiotu na taski(Traktowanie przedmiotu jak projektu)
 * Dodawanie zadania do poszczegulnego przedmiotu
 * Usuwanie zadania poszczegulnego przedmiotu 
 * Dodawanie przedmiotów
 * Oznaczenie zadania jako ukończone
 * Wyswietlenie zadania z najbliższym deadline
 * Oznaczenie rozpoczęcia realizacji taska
 * Alerty/uwagi gdy za duzo tasków na tydzien
 * Zastanowić się nad realizacją zadan(
 * 
 * 
 */
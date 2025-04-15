namespace StudentRecordSystem
{
    internal class Student
    {
        public int StudentId { get; }
        private static int count = 0;
        public string Name { get; set; }

        public List<Dictionary<string, int>> StudentRecord { get; set; }
        public Dictionary<string, int> SubjectGrade { get; set; }

        public Student(string studentName)
        {
            StudentId = count++;
            Name = studentName;
            StudentRecord = new List<Dictionary<string, int>>();
        }
        public void ViewAllSubjectGrades()
        {
            foreach (var items in StudentRecord)
            {
                foreach (var item in items)
                {
                    Console.WriteLine($"Subject: {item.Key}, Grade: {item.Value}");
                }
            }
        }


        public void AddSubject(string subject)
        {
            StudentRecord.Add(new Dictionary<string, int>
            {
                [subject] = 0,
            });
        }

        public bool AddSubjectGrade(string subject, int grade)
        {
            // checking if ANY dictionaries contain key -> subject
            bool isSubjectInRecord = StudentRecord.Any(dict => dict.ContainsKey(subject));
            if (isSubjectInRecord)
            {
                if (grade > 100 || grade < 0)
                {
                    Console.WriteLine("The grade must be bewteen 0-100");
                    return false;
                }
                else
                {
                    foreach (var items in StudentRecord)
                    {
                        if (items.ContainsKey(subject))
                        {
                            items[subject] = grade;
                        }
                    }
                }
                return isSubjectInRecord;
            }
            else
            {
                Console.WriteLine("Your desired subject is not in the student record");
                return isSubjectInRecord;
            }


        }

        public int GetGrade(string subject)
        {
            foreach (var items in StudentRecord)
            {
                if (items.ContainsKey(subject))
                {
                    return items[subject];
                }
            }
            return 0;
        }




    }
}

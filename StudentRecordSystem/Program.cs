namespace StudentRecordSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What is your name?");
            string name = Console.ReadLine();

            Student student = new Student(name);
            string subject;
            int grade;
            bool recordRunning = true;
            while (recordRunning)
            {
                OptionsMenu();
                string input = Console.ReadLine();
                // we try parse the input as a int , if it doesn't transfer to an int or isn't between 1-4 we have an error
                // int.TryParse(input,out int userInput) : if int is parsed we return using 'out' the int userInput
                if (!int.TryParse(input, out int userInput) || userInput < 1 || userInput > 5)
                {
                    Console.WriteLine("You must input a number between 1-4");
                    OptionsMenu();
                }
                else
                {
                    switch (userInput)
                    {
                        case 1:
                            student.ViewAllSubjectGrades();
                            continue;

                        case 2:
                            Console.WriteLine("What subject would you like to add?");
                            subject = Console.ReadLine().ToLower();
                            student.AddSubject(subject);
                            Console.WriteLine($"{subject} successfully added to your student record!");
                            continue;

                        case 3:
                            Console.WriteLine("What subject are you adding the grade to?");
                            subject = Console.ReadLine().ToLower();
                            Console.WriteLine($"What is your grade for {subject}");
                            grade = int.Parse(Console.ReadLine());
                            bool ifDetailsValid = student.AddSubjectGrade(subject, grade);
                            if (ifDetailsValid)
                            {
                                Console.WriteLine($"Added the {grade} as the grade for {subject} in your student record");
                            }
                            continue;

                        case 4:
                            Console.WriteLine("What subject grade would you like to view?");
                            subject = Console.ReadLine().ToLower();
                            grade = student.GetGrade(subject);
                            Console.WriteLine($"Your grade for {subject} is: {grade}");
                            continue;

                        case 5:
                            recordRunning = false;
                            break;
                    }
                }

            }


        }

        public static void OptionsMenu()
        {
            Console.WriteLine("\nWelcome to your student record\n" +
                "Press '1' to view all subject grades in student record\n" +
                "Press '2' to add a new subject to student record\n" +
                "Press '3' to add a grade to a subject in student record\n" +
                "Press '4' to view a specific grade\n" +
                "Press '5' to exit your student record\n");
        }
    }
}

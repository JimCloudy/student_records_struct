using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace student_records
{
    class Program
    {
        struct student
        {
            public string id;
            public string name;
            public string sex;
            public float quiz1;
            public float quiz2;
            public float assignment;
            public float midterm;
            public float final;
            public float total;
        }

        static void Main(string[] args)
        {
            student[] students = new student[20];
            int itemCount = 0;

            string selection = "";

            while (selection != "x")
            {
                buildMenu();

                selection = Console.ReadLine();

                switch (selection)
                {
                    case "1": addStudent(students, ref itemCount);
                        break;
                    case "2": deleteStudent(students, ref itemCount);
                        break;
                    case "3": updateStudent(students, itemCount);
                        break;
                    case "4": viewAllStudents(students, itemCount);
                        break;
                    case "5": averageScore(students, itemCount);
                        break;
                    case "6": maxTotalScore(students, itemCount);
                        break;
                    case "7": minTotalScore(students, itemCount);
                        break;
                    case "8": viewStudent(students, itemCount);
                        break;
                    case "9": bubbleSortDesc(students,itemCount);
                        break;
                    case "x": break;
                    default: Console.WriteLine("Your selection is not valid: {0}", selection);
                        break;

                }
            }
        }

        static void buildMenu()
        {
            Console.WriteLine("========================================================");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("\t\t\tMENU");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("========================================================");
            Console.WriteLine();
            Console.WriteLine("1. Add Student Record");
            Console.WriteLine();
            Console.WriteLine("2. Delete Student Record");
            Console.WriteLine();
            Console.WriteLine("3. Update Student Record");
            Console.WriteLine();
            Console.WriteLine("4. View All Student Records");
            Console.WriteLine();
            Console.WriteLine("5. Calculate An Average Of A Selected Student's Scores");
            Console.WriteLine();
            Console.WriteLine("6. Show Student Who Gets The Max Total Score");
            Console.WriteLine();
            Console.WriteLine("7. Show Student Who Gets The Min Total Score");
            Console.WriteLine();
            Console.WriteLine("8. Find Student By ID");
            Console.WriteLine();
            Console.WriteLine("9. Sort Records By Total Scores");
            Console.WriteLine();
            Console.WriteLine("Enter Your Choice: ");
        }

        static void addStudent(student[] st, ref int i)
        {
            if (i > 19)
            {
                return;
            }

            student newStudent = new student();

            Console.WriteLine("========================================================");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("\t\tADD STUDENT");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("========================================================");
            Console.WriteLine();
            Console.WriteLine("Enter Student's ID: ");
            newStudent.id = Console.ReadLine();
            Console.WriteLine("Enter Student's Name: ");
            newStudent.name = Console.ReadLine();
            Console.WriteLine("Enter Student's Sex: ");
            newStudent.sex = Console.ReadLine();
            Console.WriteLine("Enter Student's Quiz 1 Score: ");
            string input = Console.ReadLine();
            newStudent.quiz1 = Convert.ToSingle(input);
            newStudent.total += newStudent.quiz1;
            Console.WriteLine("Enter Student's Quiz 2 Score: ");
            input = Console.ReadLine();
            newStudent.quiz2 = Convert.ToSingle(input);
            newStudent.total += newStudent.quiz2;
            Console.WriteLine("Enter Student's Assignment Score: ");
            input = Console.ReadLine();
            newStudent.assignment = Convert.ToSingle(input);
            newStudent.total += newStudent.assignment;
            Console.WriteLine("Enter Student's Mid-Term Score: ");
            input = Console.ReadLine();
            newStudent.midterm = Convert.ToSingle(input);
            newStudent.total += newStudent.midterm;
            Console.WriteLine("Enter Student's Final Score: ");
            input = Console.ReadLine();
            newStudent.final = Convert.ToSingle(input);
            newStudent.total += newStudent.final;

            st[i] = newStudent;

            i++;
        }

        static void viewAllStudents(student[] stud, int count)
        {
            Console.WriteLine("========================================================");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("\t\tVIEW ALL STUDENTS");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("========================================================");
            Console.WriteLine();
            for(int x = 0; x < count; x++){
                Console.WriteLine("Info For Student ID: {0}", stud[x].id);
                Console.WriteLine("\tNAME: {0}", stud[x].name);
                Console.WriteLine("\tSEX: {0}", stud[x].sex);
                Console.WriteLine("\tQUIZ 1 SCORE: {0}", stud[x].quiz1);
                Console.WriteLine("\tQUIZ 2 SCORE: {0}", stud[x].quiz2);
                Console.WriteLine("\tASSIGNMENT SCORE: {0}", stud[x].assignment);
                Console.WriteLine("\tMID-TERM SCORE: {0}", stud[x].midterm);
                Console.WriteLine("\tFINAL SCORE: {0}", stud[x].final);
                Console.WriteLine("\tTOTAL SCORE: {0}", stud[x].total);
                Console.WriteLine();
            }
        }

        static void viewStudent(student[] stud, int count)
        {
            Console.WriteLine("========================================================");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("\t\tVIEW STUDENT");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("========================================================");
            Console.WriteLine();
            Console.WriteLine("Enter Student ID: ");
            string id = Console.ReadLine();
            int x = findIndex(stud, id, count);
            if (x == -1)
            {
                return;
            }
            Console.WriteLine("Info For Student ID: {0}", stud[x].id);
            Console.WriteLine("\tNAME: {0}", stud[x].name);
            Console.WriteLine("\tSEX: {0}", stud[x].sex);
            Console.WriteLine("\tQUIZ 1 SCORE: {0}", stud[x].quiz1);
            Console.WriteLine("\tQUIZ 2 SCORE: {0}", stud[x].quiz2);
            Console.WriteLine("\tASSIGNMENT SCORE: {0}", stud[x].assignment);
            Console.WriteLine("\tMID-TERM SCORE: {0}", stud[x].midterm);
            Console.WriteLine("\tFINAL SCORE: {0}", stud[x].final);
            Console.WriteLine("\tTOTAL SCORE: {0}", stud[x].total);
            Console.WriteLine();
        }

        static void updateStudent(student[] stud, int count)
        {
            Console.WriteLine("========================================================");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("\t\tUPDATE STUDENT");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("========================================================");
            Console.WriteLine();
            Console.WriteLine("Enter Student ID: ");
            string id = Console.ReadLine();
            int x = findIndex(stud, id, count);
            if (x == -1)
            {
                return;
            }
            Console.WriteLine("Which field do you want to update?");
            Console.WriteLine("\t1. NAME: ");
            Console.WriteLine("\t2. SEX: ");
            Console.WriteLine("\t3. QUIZ 1 SCORE: ");
            Console.WriteLine("\t4. QUIZ 2 SCORE: ");
            Console.WriteLine("\t5. ASSIGNMENT SCORE: ");
            Console.WriteLine("\t6. MID-TERM SCORE: ");
            Console.WriteLine("\t7. FINAL SCORE: ");
            string input = Console.ReadLine();

            if (input == "1")
            {
                Console.WriteLine("Enter Student's Name: ");
                stud[x].name = Console.ReadLine();
            }
            if (input == "2")
            {
                Console.WriteLine("Enter Student's Sex: ");
                stud[x].sex = Console.ReadLine();
            }
            if(input == "3")
            {
                Console.WriteLine("Enter Student's Quiz 1 Score: ");
                input = Console.ReadLine();
                stud[x].quiz1 = Convert.ToSingle(input);
            }
            if(input == "4")
            {
                Console.WriteLine("Enter Student's Quiz 2 Score: ");
                input = Console.ReadLine();
                stud[x].quiz2 = Convert.ToSingle(input);
            }
            if(input == "5")
            {
                Console.WriteLine("Enter Student's Assignment Score: ");
                input = Console.ReadLine();
                stud[x].assignment = Convert.ToSingle(input);
            }
            if(input == "6")
            {
                Console.WriteLine("Enter Student's Mid-Term Score: ");
                input = Console.ReadLine();
                stud[x].midterm = Convert.ToSingle(input);
            }
            if(input == "7")
            {
                Console.WriteLine("Enter Student's Final Score: ");
                input = Console.ReadLine();
                stud[x].final = Convert.ToSingle(input);
            }

            stud[x].total = stud[x].quiz1 + stud[x].quiz2 + stud[x].assignment + stud[x].midterm + stud[x].final;
        }

        static void averageScore(student[] stud, int count)
        {
            Console.WriteLine("========================================================");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("\t\tSTUDENT AVERAGE SCORE");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("========================================================");
            Console.WriteLine();
            Console.WriteLine("Enter Student ID: ");
            string id = Console.ReadLine();
            int x = findIndex(stud, id, count);
            if (x == -1)
            {
                return;
            }
            float avg = 0;
            avg = stud[x].total / 5;
            Console.WriteLine("The Average Score For Student {0} is: {1}", id, avg);
        }

        static void maxTotalScore(student[] stud, int count)
        {
            float max = -1;
            string maxId = "";
            for (int x = 0; x < count; x++)
            {
                if (stud[x].total > max)
                {
                    max = stud[x].total;
                    maxId = stud[x].id;
                }
            }
            int index = findIndex(stud, maxId, count);
            if (index == -1)
            {
                return;
            }
            Console.WriteLine("========================================================");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("\t\tMAX STUDENT SCORE");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("========================================================");
            Console.WriteLine();
            Console.WriteLine("Info For Student ID: {0}", stud[index].id);
            Console.WriteLine("\tNAME: {0}", stud[index].name);
            Console.WriteLine("\tSEX: {0}", stud[index].sex);
            Console.WriteLine("\tQUIZ 1 SCORE: {0}", stud[index].quiz1);
            Console.WriteLine("\tQUIZ 2 SCORE: {0}", stud[index].quiz2);
            Console.WriteLine("\tASSIGNMENT SCORE: {0}", stud[index].assignment);
            Console.WriteLine("\tMID-TERM SCORE: {0}", stud[index].midterm);
            Console.WriteLine("\tFINAL SCORE: {0}", stud[index].final);
            Console.WriteLine("\tTOTAL SCORE: {0}", stud[index].total);
            Console.WriteLine();

        }

        static void minTotalScore(student[] stud, int count)
        {
            float min = 999;
            string minId = "";
            for (int x = 0; x < count; x++)
            {
                if (stud[x].total < min)
                {
                    min = stud[x].total;
                    minId = stud[x].id;
                }
            }
            int index = findIndex(stud, minId, count);
            if (index == -1)
            {
                return;
            }
            Console.WriteLine("========================================================");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("\t\tMIN STUDENT SCORE");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("========================================================");
            Console.WriteLine();
            Console.WriteLine("Info For Student ID: {0}", stud[index].id);
            Console.WriteLine("\tNAME: {0}", stud[index].name);
            Console.WriteLine("\tSEX: {0}", stud[index].sex);
            Console.WriteLine("\tQUIZ 1 SCORE: {0}", stud[index].quiz1);
            Console.WriteLine("\tQUIZ 2 SCORE: {0}", stud[index].quiz2);
            Console.WriteLine("\tASSIGNMENT SCORE: {0}", stud[index].assignment);
            Console.WriteLine("\tMID-TERM SCORE: {0}", stud[index].midterm);
            Console.WriteLine("\tFINAL SCORE: {0}", stud[index].final);
            Console.WriteLine("\tTOTAL SCORE: {0}", stud[index].total);
            Console.WriteLine();

        }

        static void deleteStudent(student[] stud, ref int count)
        {
            Console.WriteLine("========================================================");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("\t\tDELETE STUDENT");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("========================================================");
            Console.WriteLine();
            Console.WriteLine("Enter Student ID: ");
            string id = Console.ReadLine();
            int x = findIndex(stud, id, count);
            if (x == -1)
            {
                return;
            }
            
            if (x == count - 1)
            {
                stud[x].id = null;
                stud[x].name = null;
                stud[x].sex = null;
                stud[x].quiz1 = 0;
                stud[x].quiz2 = 0;
                stud[x].assignment = 0;
                stud[x].midterm = 0;
                stud[x].final = 0;
                stud[x].total = 0;

                count--;
                return;
            }

            for (int y = x+1; y < count; y++)
            {
                stud[y - 1] = stud[y];
            }

            stud[count - 1].id = null;
            stud[count - 1].name = null;
            stud[count - 1].sex = null;
            stud[count - 1].quiz1 = 0;
            stud[count - 1].quiz2 = 0;
            stud[count - 1].assignment = 0;
            stud[count - 1].midterm = 0;
            stud[count - 1].final = 0;
            stud[count - 1].total = 0;

            count--;

        }

        static void bubbleSortDesc(student[] stud, int count)
        {
            student temp = new student();

            for (int x = 0; x < count; x++)
            {
                for (int y = count - 1; y > x; y--)
                {
                    if (stud[y].total > stud[x].total)
                    {
                        temp = stud[x];
                        stud[x] = stud[y];
                        stud[y] = temp;
                    }
                }
            }
        }

        static int findIndex(student[] stud, string id, int count)
        {
            for (int x = 0; x < count; x++)
            {
                if (stud[x].id == id)
                {
                    return x;
                }
            }
            return -1;
        }
    }
}

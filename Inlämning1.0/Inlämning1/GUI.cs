//Julian Blair 14/09/10
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inlämning1
{
    /// <summary>
    /// Handles Interface and user input
    /// </summary>
    class GUI
    {
        private string user_Input;
        private char c1; //topmost character in stack
        private char c2; //next character in user input
        private bool matches; //variable for Ismatch
        private Stack s; //object declaration
        private bool bracketOK; //holds return value for BracketOKCheck

        /// <summary>
        /// Determines whether the specified character in stack is match.
        /// </summary>
        /// <param name="characterInStack">The character in stack.</param>
        /// <param name="characterUserInput">The character user input.</param>
        /// <returns></returns>
        private bool IsMatch(char characterInStack, char characterUserInput)
        {
            characterInStack = (char)s.peek(); //on second check the character in stack is still '['. Need to get the character from s.peek instead?
            characterUserInput = c2; //userInput correct on second check

            if ((characterInStack == '(') && (characterUserInput != ')'))
            {
                matches = false; return matches;
            }

            else if ((characterInStack == '[') && (characterUserInput != ']'))
            {
                matches = false; return matches; //on second run the wrong values are being compared so the method returns false
            }

            else if ((characterInStack == '{') && (characterUserInput != '}'))
            {
                matches = false; return matches;
            }

            else
                matches = true; return matches;
        }

        /// <summary>
        /// Starts this instance.
        /// </summary>
        public void Start()
        {
            s = new Stack();

            const int max_Number_Of_Input = 100;

            for (int i = 0; i < max_Number_Of_Input; i++)
            {
                Console.WriteLine("(" + s.ReturnCount.ToString() + ")" + " ELEMENTS IN STACK");
                Console.WriteLine("-------------------------------------------------------");
                Console.Write("Please enter string:");
                user_Input = Console.ReadLine();
                Console.WriteLine("-------------------------------------------------------");
                CheckInput(user_Input);
            }
        }

        /// <summary>
        /// Pushes the specified character.
        /// </summary>
        /// <param name="character">The character.</param>
        private void Push(char character)
        {
            s.push(character); //pushes only the above characters to the stack
            Console.WriteLine("Check for matching element ...\n");
        }

        /// <summary>
        /// Pops the character.
        /// </summary>
        private void Pop()
        {
            if (((char)s.peek() == '(' || ((char)s.peek() == '{' || ((char)s.peek() == '['))) && (IsMatch(c1, c2))) // when input is )( there is a null reference exception on this line!
            {
                s.pop();
                Console.WriteLine("Match found.\nElement popped from stack: " + s.ReturnTemp.ToString());
                if (s.peek() != null)
                {
                    Console.WriteLine("Topmost element in stack: " + s.peek().ToString());
                    Console.WriteLine(s.ReturnCount.ToString() + " element(s) in stack.");
                }
            }

            else
            {
                Reset();
            }
        }

        /// <summary>
        /// Resets the GUI.
        /// </summary>  
        private void Reset()
        {
            Console.WriteLine("Mismatch detected.\nPlease use correct syntax!\nRESETTING ... \n\n");
            Start();
        }

        /// <summary>
        /// Checks the order of brackets.
        /// </summary>
        private bool BracketOKCheck() 
        {
            if ((s.peek() == null))
            {
                bracketOK = false;
                Console.WriteLine("Cannot start with closed bracket"); // if bracket check false then this line prints otherwise continue
                return bracketOK;
            }
            else return true;
        }

        /// <summary>
        /// Checks the input.
        /// </summary>
        /// <param name="input">The input.</param>
        public void CheckInput(string input)
        {
            foreach (char c in user_Input)
            {
                if (c == '(' || c == '[' || c == '{') //if open then push call
                {
                    c1 = c;
                    Push(c1);
                }

                else if (c == ')' || c == ']' || c == '}') //if closed then bracket check and pop call
                {
                    c2 = c;

                    if (BracketOKCheck())
                    {

                        if ((c2 == ')'))
                        {
                            Pop();
                        }

                        if (c2 == ']')
                        {
                            Pop();
                        }

                        if (c2 == '}')
                        {
                            Pop();
                        }

                        if (s.peek() == null) //if stack is empty
                        {
                            Console.WriteLine("Stack is now empty.\n");
                        }
                    }
                    else break; //if BracketCheckOK returns false, system breaks out of the else if to the Start() call below
                }
            }
            Start(); //if two open are detected the Stack is renewed and a messages showing number of elements is displayed (allting nollställas)
        }
    }
}

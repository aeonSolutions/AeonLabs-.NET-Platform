using System;
using System.Diagnostics;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace AeonLabs.CrashAndDiagnostics
{
    static class CrashDataLib
    {
        public static bool saveCrash(Exception e)
        {
            var state = new environmentVars(LOAD_SETTINGS);
            if (state.SendDiagnosticData.Equals(false))
            {
                return true;
            }

            var trace = new StackTrace(e, true);
            string line = Strings.Right(trace.ToString(), 5);
            int Xcont = 0;
            string report = e.Message.ToString().Replace("'", "") + Environment.NewLine;
            report += "--------- Stack trace ---------" + Environment.NewLine;
            report += "----------" + DateTime.Now.ToString() + "----------" + Environment.NewLine;
            report += "----------OS version:" + Assembly.GetExecutingAssembly().GetName().Version.ToString + "----------" + Environment.NewLine;
            report += "    Error Line:" + Strings.Right(trace.ToString(), 5) + Environment.NewLine;
            report += "-------------------------------" + Environment.NewLine;
            report += "--------- Cause ---------" + Environment.NewLine;
            foreach (StackFrame sf in trace.GetFrames())
            {
                Xcont = Xcont + 1;
                report += Xcont + "- " + sf.GetMethod().ReflectedType.ToString().Replace("'", "") + " " + sf.GetMethod().Name.Replace("'", "") + Environment.NewLine;
            }

            report += "-------------end report---------------" + Environment.NewLine;
            ;
#error Cannot convert LocalDeclarationStatementSyntax - see comment for details
            /* Cannot convert LocalDeclarationStatementSyntax, System.NotSupportedException: StaticKeyword not supported!
               at ICSharpCode.CodeConverter.CSharp.SyntaxKindExtensions.ConvertToken(SyntaxKind t, TokenContext context)
               at ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifier(SyntaxToken m, TokenContext context)
               at ICSharpCode.CodeConverter.CSharp.CommonConversions.<ConvertModifiersCore>d__40.MoveNext()
               at System.Linq.Enumerable.<ConcatIterator>d__59`1.MoveNext()
               at System.Linq.Enumerable.WhereEnumerableIterator`1.MoveNext()
               at System.Linq.Buffer`1..ctor(IEnumerable`1 source)
               at System.Linq.OrderedEnumerable`1.<GetEnumerator>d__1.MoveNext()
               at Microsoft.CodeAnalysis.SyntaxTokenList.CreateNode(IEnumerable`1 tokens)
               at ICSharpCode.CodeConverter.CSharp.CommonConversions.ConvertModifiers(SyntaxNode node, IReadOnlyCollection`1 modifiers, TokenContext context, Boolean isVariableOrConst, SyntaxKind[] extraCsModifierKinds)
               at ICSharpCode.CodeConverter.CSharp.MethodBodyExecutableStatementVisitor.<VisitLocalDeclarationStatement>d__31.MoveNext()
            --- End of stack trace from previous location where exception was thrown ---
               at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
               at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
               at ICSharpCode.CodeConverter.CSharp.HoistedNodeStateVisitor.<AddLocalVariablesAsync>d__6.MoveNext()
            --- End of stack trace from previous location where exception was thrown ---
               at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
               at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
               at ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.<DefaultVisitInnerAsync>d__3.MoveNext()

            Input:

                    Static start As Single

             */
            start = Conversions.ToSingle(DateAndTime.Timer);
            try
            {
                System.IO.StreamWriter file;
                file = My.MyProject.Computer.FileSystem.OpenTextFileWriter(Path.Combine(string.Format(@"{0}\", Environment.CurrentDirectory), "crash.log"), true);
                file.WriteLine(report + Environment.NewLine);
                file.Close();
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }
    }
}
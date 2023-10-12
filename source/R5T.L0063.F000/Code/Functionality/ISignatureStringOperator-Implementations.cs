using System;
using System.Collections.Generic;
using System.Text;


namespace R5T.L0063.F000.Implementations
{
    public partial interface ISignatureStringOperator
    {
        /// <summary>
        /// Combines list item tokens according to generic type list open and close tokens.
        /// Useful for both parameter lists and generic type input lists.
        /// </summary>
        /// <remarks>
        /// See <see cref="F000.ISignatureStringOperator.Get_ListItems(string)"/>.
        /// </remarks>
        public string[] Get_ListItems(string[] listItemTokens)
        {
            var listItems = new List<string>();

            int genericTypeOpenTokensCount = 0;
            int genericTypeCloseTokensCount = 0;

            var builder = new StringBuilder();

            foreach (var token in listItemTokens)
            {
                builder.Append(token);

                genericTypeOpenTokensCount += Instances.StringOperator.CountOf(
                    Instances.TokenSeparators.GenericTypeListOpenTokenSeparator,
                    token);

                genericTypeCloseTokensCount += Instances.StringOperator.CountOf(
                    Instances.TokenSeparators.GenericTypeListCloseTokenSeparator,
                    token);

                if (genericTypeOpenTokensCount == genericTypeCloseTokensCount)
                {
                    genericTypeOpenTokensCount = 0;
                    genericTypeCloseTokensCount = 0;

                    var parameterToken = builder.ToString();
                    builder.Clear();

                    listItems.Add(parameterToken);
                }
                else
                {
                    // Add back the standard separator.
                    builder.Append(Instances.TokenSeparators.ListItemSeparator);
                }
            }

            var output = listItems.ToArray();
            return output;
        }
    }
}

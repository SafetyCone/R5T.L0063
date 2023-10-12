using System;

using R5T.T0131;


namespace R5T.L0063.Z000
{
    [ValuesMarker]
    public partial interface ITokenSeparators : IValuesMarker,
        // Use the kind-marker separator from the identity string library.
        L0062.L001.ITokenSeparators
    {
        /// <summary>
        /// <para>", " (comma and space)</para>
        /// </summary>
        public const string ArgumentListSeparator_Constant = ", ";

        /// <inheritdoc cref="ArgumentListSeparator_Constant"/>
        public string ArgumentListSeparator => ArgumentListSeparator_Constant;

        /// <summary>
        /// <para>'#' (hash)</para>
        /// Separates the namespaced type name parts of an explicitly implemented name.
        /// </summary>
        public const char ExplicitImplementationNamespaceTokenSeparator_Constant = '#';

        /// <inheritdoc cref="ExplicitImplementationNamespaceTokenSeparator_Constant"/>
        public char ExplicitImplementationNamespaceTokenSeparator => ExplicitImplementationNamespaceTokenSeparator_Constant;

        /// <summary>
        /// <para>'&lt;' (open angle-bracket)</para>
        /// Used for both type parameter, and type argument lists.
        /// </summary>
        public const char GenericTypeListOpenTokenSeparator_Constant = '<';

        /// <inheritdoc cref="GenericTypeListOpenTokenSeparator_Constant"/>
        public char GenericTypeListOpenTokenSeparator => GenericTypeListOpenTokenSeparator_Constant;

        /// <summary>
        /// <para>'&gt;' (close angle-bracket)</para>
        /// </summary>
        public const char GenericTypeListCloseTokenSeparator_Constant = '>';

        /// <inheritdoc cref="GenericTypeListCloseTokenSeparator_Constant"/>
        public char GenericTypeListCloseTokenSeparator => GenericTypeListCloseTokenSeparator_Constant;

        /// <summary>
        /// <para>',' (comma)</para>
        /// </summary>
        public const char ListItemSeparator_Constant = ',';

        /// <inheritdoc cref="ListItemSeparator_Constant"/>
        public char ListItemSeparator => ListItemSeparator_Constant;

        /// <summary>
        /// <para>'.' (period)</para>
        /// Separates tokens in a namespaced name (namespace name, namespaced type name) from each other.
        /// </summary>
        public const char NamespaceTokenSeparator_Constant = '.';

        /// <inheritdoc cref="NamespaceTokenSeparator_Constant"/>
        public char NamespaceTokenSeparator => NamespaceTokenSeparator_Constant;

        /// <inheritdoc cref="NamespaceTokenSeparator_Constant"/>
        public const string NamespaceTokenSeparator_String_Constant = ".";

        /// <inheritdoc cref="NamespaceTokenSeparator_String_Constant"/>
        public string NamespaceTokenSeparator_String => NamespaceTokenSeparator_String_Constant;

        /// <summary>
        /// <para><name>'+' (plus)</name></para>
        /// Separates tokens in a nested type name (parent type name, child type name) from each other.
        /// </summary>
        public const char NestedTypeNameTokenSeparator_Constant = '+';

        /// <inheritdoc cref="NestedTypeNameTokenSeparator_Constant"/>
        public char NestedTypeNameTokenSeparator => NestedTypeNameTokenSeparator_Constant;

        /// <inheritdoc cref="NestedTypeNameTokenSeparator_Constant"/>
        public const string NestedTypeNameTokenSeparator_String_Constant = "+";

        /// <inheritdoc cref="NestedTypeNameTokenSeparator_String_Constant"/>
        public string NestedTypeNameTokenSeparator_String => NestedTypeNameTokenSeparator_String_Constant;

        /// <summary>
        /// <para>'(' (open-parenthesis)</para>
        /// Separates the namespaced, typed, method name from its parameter list.
        /// </summary>
        public const char ParameterListOpenTokenSeparator_Constant = '(';

        /// <inheritdoc cref="ParameterListOpenTokenSeparator_Constant"/>
        public char ParameterListOpenTokenSeparator => ParameterListOpenTokenSeparator_Constant;

        /// <summary>
        /// <para>' ' (space)</para>
        /// Separates the namespaced type name of a parameter from the name of a parameter.
        /// </summary>
        public const char ParameterNameTokenSeparator_Constant = ' ';

        /// <inheritdoc cref="ParameterNameTokenSeparator_Constant"/>
        public char ParameterNameTokenSeparator => ParameterNameTokenSeparator_Constant;

        /// <summary>
        /// <para>')' (close-parenthesis)</para>
        /// Closes the parameter list for a method identity string.
        /// </summary>
        public const char ParameterListCloseTokenSeparator_Constant = ')';

        /// <inheritdoc cref="ParameterListCloseTokenSeparator_Constant"/>
        public char ParameterListCloseTokenSeparator => ParameterListCloseTokenSeparator_Constant;

        /// <summary>
        /// <para>'~' (tilde)</para>
        /// Separates the namespaced, typed, argumented, method name from its output type.
        /// Used for implicit and explicit operator methods.
        /// </summary>
        public const char OutputTypeTokenSeparator_Constant = '~';

        /// <inheritdoc cref="OutputTypeTokenSeparator_Constant"/>
        public char OutputTypeTokenSeparator => OutputTypeTokenSeparator_Constant;

        /// <inheritdoc cref="GenericTypeListOpenTokenSeparator_Constant"/>
        public const char TypeArgumentListOpenTokenSeparator_Constant = GenericTypeListOpenTokenSeparator_Constant;

        /// <inheritdoc cref="TypeArgumentListOpenTokenSeparator_Constant"/>
        public char TypeArgumentListOpenTokenSeparator => TypeArgumentListOpenTokenSeparator_Constant;

        /// <inheritdoc cref="GenericTypeListCloseTokenSeparator_Constant"/>
        public const char TypeArgumentListCloseTokenSeparator_Constant = GenericTypeListCloseTokenSeparator_Constant;

        /// <inheritdoc cref="TypeArgumentListCloseTokenSeparator_Constant"/>
        public char TypeArgumentListCloseTokenSeparator => TypeArgumentListCloseTokenSeparator_Constant;
    }
}



namespace WCORE.Utility.SQLBuilder
{
    public enum Comparison
    {
        Equals,
        NotEquals,
        Like,
        NotLike,
        GreaterThan,
        GreaterOrEquals,
        LessThan,
        LessOrEquals,
        In
    }

    public enum JoinType
    {
        InnerJoin,
        OuterJoin,
        LeftJoin,
        RightJoin
    }

    public enum LogicOperator
    {
        And,
        Or
    }

    public enum Sorting
    {
        Ascending,
        Descending
    }

    public enum TopUnit
    {
        Records,
        Percent
    }
}

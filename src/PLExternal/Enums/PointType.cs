namespace PLExternal.Enums
{
    /// <summary>
    ///     Тип точки
    /// </summary>
    public enum PointType
    {
        /// <summary>
        ///     Обычная точка
        /// </summary>
        Default = 0,

        /// <summary>
        ///     Начальная точка уровня
        /// </summary>
        Start = 1,

        /// <summary>
        ///     Конечная точка уровня
        /// </summary>
        Finish = 2,

        /// <summary>
        ///     Побочная точка, которая не приведёт ни к концу, ни к началу уровня
        /// </summary>
        Side = 3,
    }
}

namespace BattleElements
{
    public static class EnemyData
    {
        static EnemyActor[] enemyFrontline = new EnemyActor[3];
        static EnemyActor[] enemyBackline = new EnemyActor[3];

        public static EnemyActor[] Enemies { get; internal set; }
        internal static EnemyActor[] EnemyFrontline { get => enemyFrontline; set => enemyFrontline = value; }
        internal static EnemyActor[] EnemyBackline { get => enemyBackline; set => enemyBackline = value; }
    }
}
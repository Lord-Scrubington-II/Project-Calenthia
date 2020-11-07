namespace BattleElements
{
    internal class EnemyData
    {
        static EnemyActor[] enemyFrontline = new EnemyActor[3];
        static EnemyActor[] enemyBackline = new EnemyActor[3];

        public static GenericActor[] Enemies { get; internal set; }
        internal static EnemyActor[] EnemyFrontline { get => enemyFrontline; set => enemyFrontline = value; }
        internal static EnemyActor[] EnemyBackline { get => enemyBackline; set => enemyBackline = value; }
    }
}
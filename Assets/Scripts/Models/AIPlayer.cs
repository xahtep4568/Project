using System;
using System.Threading.Tasks;
using Unity.Mathematics;
using Random = System.Random;

namespace TicTacToe.Models
{
    
    public class AiPlayer : IPlayer
    {

        private const int RandomTriesCount = 10;
        
        private Random random;
        
        public AiPlayer(CellSign sign)
        {
            Sign = sign;
            random = new Random();
        }
        
        public CellSign Sign { get; }
        
        public event Action<IPlayer, int2> OnMadeTurn;
        
        public async void StartTurn(IGameField field)
        {
            await Task.Delay(TimeSpan.FromSeconds(3));

            var selected = TrySelectRandom(field);
            if (!selected) TrySelectAny(field);
        }

        private bool TrySelectRandom(IGameField field)
        {
            var size = field.Size;
            for (int i = 0; i < RandomTriesCount; ++i)
            {
                var pos = new int2(random.Next(size.x), random.Next(size.y));
                if (field[pos] != CellSign.Empty) continue;
                
                OnMadeTurn?.Invoke(this, pos);
                return true;
            }

            return false;
        }

        private void TrySelectAny(IGameField field)
        {
            var size = field.Size;
            for (int x = 0; x < size.x; ++x)
            {
                for (int y = 0; y < size.y; ++y)
                {
                    var pos = new int2(x, y);
                    if (field[pos] != CellSign.Empty) continue;
                    
                    OnMadeTurn?.Invoke(this, pos);
                    return;
                }
            }
        }
        
    }
    
}
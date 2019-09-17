using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public interface IPlayer 
{
	//Вот здесь я не знаю как реализовать интерфейс так, чтобы метод вызывался общим для игрока и бота
	bool Turn(int x, int y);
	bool Hold();
	char GetSymb{ get;}
	void SetSymb (char startSymbol);
}

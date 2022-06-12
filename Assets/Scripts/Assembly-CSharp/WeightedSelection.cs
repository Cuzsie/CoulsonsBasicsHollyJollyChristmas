using System;
using UnityEngine;

// Token: 0x020000DC RID: 220
[Serializable]
public class WeightedSelection<T>
{
	// Token: 0x06000A06 RID: 2566 RVA: 0x000279A0 File Offset: 0x00025DA0
	public static T RandomSelection(WeightedSelection<T>[] items)
	{
		int num = 0;
		int num2 = 0;
		foreach (WeightedSelection<T> weightedSelection in items)
		{
			num2 += weightedSelection.weight;
		}
		int num3 = UnityEngine.Random.Range(0, num2);
		int j;
		for (j = 0; j < items.Length; j++)
		{
			num += items[j].weight;
			if (num > num3)
			{
				break;
			}
		}
		if (j < items.Length)
		{
			return items[j].selection;
		}
		Debug.Log("No valid selection found. Returning index 0");
		return items[0].selection;
	}

	// Token: 0x04000757 RID: 1879
	public T selection;

	// Token: 0x04000758 RID: 1880
	public int weight;
}

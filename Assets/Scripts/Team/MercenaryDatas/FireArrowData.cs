using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "FireArrowData", menuName = "MercenaryData/FireArrowData")]
public class FireArrowData : MercenaryData,IStat_AddPjt,IStat_DebuffRate
{
    [field: SerializeField] public Stat DebuffRate { get; protected set; }
    [field: SerializeField] public Stat Piercing { get; protected set; }
    [field: SerializeField] public Stat AddPjtCount { get; protected set; }

    private void OnEnable()
    {
        StatsByLevel = new UpStatData[]
 {
            new UpStatData( UpStatChecking,"공격력이 15 증가합니다.",()=>{
                     Damage.Value+= 15;},Damage),
            new UpStatData( UpStatChecking,"공격속도가 5 증가합니다.",()=>{ CoolTime.Value-= 5; },CoolTime),
            new UpStatData( UpStatChecking,"범위가 10 증가합니다.",()=>{ Range.Value+= 10; }, Range),
            new UpStatData( UpStatChecking, "크리티컬 확률이 2증가합니다.",() => { CriticalPer.Value += 2; }, CriticalPer),
             new UpStatData( UpStatChecking,"공격이 30%확률로 화상을 입힙니다.",
            ()=>{DebuffRate.Value+=30;
                _characteristic[0].Add(Effector.Effectors[(int)Common.eEffector.e화염묻히기]); } ,DebuffRate),
            new UpStatData( UpStatChecking, "공격력이 15 증가합니다.",()=>{ Damage.Value+= 15; }, Damage),
            new UpStatData( UpStatChecking, "공격속도가 5 증가합니다.",() => { CoolTime.Value -= 5; }, CoolTime),
            new UpStatData( UpStatChecking, "범위가 10 증가합니다.",()=>{ Range.Value+= 10; },Range),
            new UpStatData( UpStatChecking, "크리티컬 확률이 2증가합니다.",()=>{ CriticalPer.Value+= 2; }, CriticalPer),
            new UpStatData( UpStatChecking,"2성 특성에 갈래화살이 추가됩니다.",
            ()=>{                AddPjtCount.Value++;
                _characteristic[1].Add(Effector.Effectors[(int)Common.eEffector.e갈래화살]); } ,AddPjtCount),
            new UpStatData( UpStatChecking, "공격력이 15 증가합니다.",()=>{ Damage.Value+= 15; }, Damage),
            new UpStatData( UpStatChecking, "공격속도가 5 증가합니다.",()=>{ CoolTime.Value-= 5; }, CoolTime),
            new UpStatData( UpStatChecking, "범위가 10 증가합니다.",()=>{ Range.Value+= 10; }, Range),
            new UpStatData( UpStatChecking, "크리티컬 확률이 2증가합니다.",()=>{ CriticalPer.Value+= 2; }, CriticalPer),

 };
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Readme : MonoBehaviour
{
}


// https://www.hallgrimgames.com/

// Vertical Layout Group

// Control Child Size
// 1. 자식 객체의 크기를 부모가 제어하겠다.
// 2. 대부분 0의 초기값을 가짐, 단  Image/Text는 예외, texture 가지면 해당 크기가 사용이 됨
// 3. 자식의 Height field는 disabled 되어서 조정 불가 상태

// Child Force Expand
// 1. 사용치 않은 공간(nunsed space)이 있다면 자식을 확장해서 채우겠다.
// 2.  Unsed space: 부모 height - 모든 자식들의 preferred/min height 합.

// Layout Element
// 1. 객체의 크기가 이렇게 되면 좋겠다라는 정보를 제공, 기존 정보를 override 시킴
// 2. Min, Preferred, Flexible
// 3. Flexible: 단위가  ration(weight)
// 4. Image/Text componests는 preferred 값이 자동으로 설정된다. 단 실제 texture가 할당된 경우만 가능하다.
// 5. Flexible 이 제대로 동작하려면 부모의 Child Force Expand를 off해야 한다.

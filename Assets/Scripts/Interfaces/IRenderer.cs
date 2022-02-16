using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

interface IRenderer
{


    IEnumerator CheckRender();
    IEnumerator DelayedStart();

}

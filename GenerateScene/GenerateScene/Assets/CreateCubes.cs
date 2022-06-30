using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class CreateCubes : MonoBehaviour
{
    private Vector3[] dataar;
    public Transform Parent;
    // Start is called before the first frame update
    void Start()
    {
        //---------------------------------------------------------Debug Byte array-----------
        string path = "C:/Users/ingeniarius/Downloads/forest"; //change the path!
        byte[] bytedata; bytedata = File.ReadAllBytes(path);
        float _x = 0, _y = 0, _z = 0;

        byte[] FourBytes = new byte[4];

        int iP = 0;

        List<Vector3> pointdatalist = new List<Vector3>();

        for (int i = 0; i < bytedata.Length; i = i + 16)
        {
            FourBytes[0] = bytedata[i + 0];
            FourBytes[1] = bytedata[i + 1];
            FourBytes[2] = bytedata[i + 2];
            FourBytes[3] = bytedata[i + 3];
            if (BitConverter.IsLittleEndian == false)
                Array.Reverse(FourBytes);
            _x = BitConverter.ToSingle(FourBytes, 0);

            FourBytes[0] = bytedata[i + 4];
            FourBytes[1] = bytedata[i + 5];
            FourBytes[2] = bytedata[i + 6];
            FourBytes[3] = bytedata[i + 7];
            if (BitConverter.IsLittleEndian == false)
                Array.Reverse(FourBytes);
            _y = BitConverter.ToSingle(FourBytes, 0);

            FourBytes[0] = bytedata[i + 8];
            FourBytes[1] = bytedata[i + 9];
            FourBytes[2] = bytedata[i + 10];
            FourBytes[3] = bytedata[i + 11];
            if (BitConverter.IsLittleEndian == false)
                Array.Reverse(FourBytes);
            _z = BitConverter.ToSingle(FourBytes, 0);


            Vector3 dt = new Vector3
            {
                x = _x,
                y = _y,
                z = _z,
            };
            pointdatalist.Add(dt);
            dataar = pointdatalist.ToArray();


        }
        for (int ii = 0; ii < dataar.Length; ii++)
        {
            // Debug.Log(dataar[ii].x + " " + dataar[ii].y + " " + dataar[ii].z);
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.SetParent(Parent);
            cube.transform.localPosition = new Vector3(dataar[ii].x, dataar[ii].y, dataar[ii].z);
            cube.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);

        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

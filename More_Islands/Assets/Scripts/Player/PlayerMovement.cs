using UnityEngine;
using System.Collections;
using Zenject;


public class PlayerMovement : MonoBehaviour
{

    public void PlayerMoving(Transform player, Vector2 direction, float speedScale)
    {
        float moveSpeed = speedScale * Time.deltaTime;

        Vector3 moveDirection = new Vector3(direction.x, 0, direction.y);
        player.position += moveDirection * moveSpeed;
    }

    public void PlayerJumping(Transform player, AnimationCurve jumpTrajectory, float durarion, float jumpForce)
    {
        StartCoroutine(playerJump(player, jumpTrajectory, durarion, jumpForce));
    }

    private IEnumerator playerJump(Transform player, AnimationCurve jumpTrajectory, float durarion, float jumpForce)
    {
        float expiredTime = 0;
        float jumpProgress = 0;
        Vector3 startPositon = player.position;

        while (jumpProgress < 1)
        {  
            Debug.Log(jumpProgress);
            expiredTime += Time.deltaTime;
            jumpProgress = expiredTime / durarion; 

            Vector3 nextPosiotion = startPositon + new Vector3(0, jumpTrajectory.Evaluate(jumpProgress) * jumpForce, 0);

           // player.position = nextPosiotion * Time.deltaTime;
            player.position = Vector3.Lerp(player.position, nextPosiotion, jumpProgress);
            yield return new WaitForSeconds(0.0001f);
            Debug.Log(player.position);
        }

        yield return null;

    }
}




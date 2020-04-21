# GE2_LabTest

Initial idea is to use 2 Finite state machines.

First spawn in 10 traffic light cylinders in a cirlce with the center being the origin.
Traffic lights will be stored in a list
Their initial state will be set to a random of green, yellow or red.

--Traffic light state machine--
3 states. green, yellow and red

Green Coroutine
sets GO color / material to green
generate rand_num between 5 and 10
wait for rand_num seconds
swicth state to yellow and starts yellow coroutine

Yellow Coroutine
set GO color / material to yellow
wait 4 seconds
switch state to red and start red coroutine

Red Coroutine
sets GO color / material to red
generate rand_num between 5 and 10
wait for rand_num seconds
swicth state to green and starts green coroutine

--Car State Machine--

2 states. PickTarget and ArriveTarget

Init car in PickTarget state

PickTarget
pick rand_num between 0 and trafficlightList.count
targetGO = trafficlightList[rand_num]
if (targetGO.stae == green)
{ change state to ArriveTarget start ArriveTarget and then return }

ArriveTarget
while (targetGO.state == green)
{ implement arrive behaviour 
  if speed = 0 (you have arrived)
  change state to PickTarget and start PickTarget and then return
}

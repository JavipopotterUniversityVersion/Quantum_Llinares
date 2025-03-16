function GetRandomPosition()
    return Vector3(GenerateRandomNumber(-9, 9), 
                   GenerateRandomNumber(-5, 5),
                   0)
end

function GetRandomRotation()
    return Quaternion.Euler(0, 0, GenerateRandomNumber(0, 360))
end

local fishes = GetFishes();
function RandomSpawn(numberOfFish, posibleFishes)
    for i=1, numberOfFish do
        local pos = GetRandomPosition()
        local rot = GetRandomRotation()
        SpawnFish(fishes[GenerateRandomInt(1, posibleFishes)], pos, rot)
    end
end

RandomSpawn(10, 3)

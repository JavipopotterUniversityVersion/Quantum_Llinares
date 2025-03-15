function GetRandomPosition()
    return Vector3(GenerateRandomNumber(-9, 9), 
                   GenerateRandomNumber(-5, 5),
                   0)
end

function GetRandomRotation()
    return Quaternion.Euler(0, 0, GenerateRandomNumber(0, 360))
end

function RandomSpawn(numberOfFish, posibleFishes)
    for i=1, numberOfFish do
        local pos = GetRandomPosition()
        local rot = GetRandomRotation()
        local fish = fishes[GenerateRandomNumber(0, posibleFishes)]
        SpawnFish("Fish1", pos, rot)
    end
end

RandomSpawn(10, 2);

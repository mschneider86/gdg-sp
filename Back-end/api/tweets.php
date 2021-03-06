<?php
/*
 * Copyright (C) 2017 Alefe Souza <contact@alefesouza.com>
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

include("../index.php");

use GDGSP\API\TwitterAPI;

$token = TwitterAPI::getToken();
$api = new TwitterAPI($token);

$max_id = isset($_GET["max_id"]) ? $_GET["max_id"] : "";

$tweets = $api->getTweets($max_id);

echo $api->makeAppJson($tweets);
?>